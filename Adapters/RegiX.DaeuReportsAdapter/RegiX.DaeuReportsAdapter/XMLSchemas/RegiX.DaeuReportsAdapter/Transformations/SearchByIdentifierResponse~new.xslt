<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/DaeuReports/SearchByIdentifierResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:SearchByIdentifierResponse">
						<br/>
						<h3 align="center">
							<span>
								<xsl:text>Държавна агенция „Електронно управление”</xsl:text>
							</span>
						</h3>
						<h3 align="center">
							<span>
								<xsl:text>Регистър на извършваните операции в средата за междурегистров обмен - RegiX</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Персонална справка на физическо лице за достъп до лични данни по идентификатор и период</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="n1:TotalResults = 0">
								<span>
									<xsl:text>Не са намерени данни за извършвани операции за подадените критерии</xsl:text>
								</span>
							</xsl:when>
							<xsl:otherwise>
								<table style="border-collapse:collapse; " border="1" width="100%">
									<thead>
										<tr>
											<th style="padding:4px; " align="left"/>
											<th height="29">
												<span>
													<xsl:text>Дата</xsl:text>
												</span>
											</th>
											<th height="29">
												<span>
													<xsl:text>Справка</xsl:text>
												</span>
											</th>
											<th height="29">
												<span>
													<xsl:text>Правно основание</xsl:text>
												</span>
											</th>
											<th height="29">
												<span>
													<xsl:text>Администрация на консуматор</xsl:text>
												</span>
											</th>
											<th height="29">
												<span>
													<xsl:text>Консуматор</xsl:text>
												</span>
											</th>
											<th height="29">
												<span>
													<xsl:text>Регистър/Система</xsl:text>
												</span>
											</th>
											<th height="29">
												<span>
													<xsl:text>Първичен администратор</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="n1:ExecutedCalls">
											<tr>
												<td style="padding:4px; ">
													<span>
														<xsl:value-of select="position()"/>
													</span>
												</td>
												<td align="center">
													<xsl:for-each select="n1:StartTime">
														<span>
															<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
															<xsl:text> </xsl:text>
															<xsl:value-of select="format-number(number(substring(substring-before(string(string(.)), ':'), string-length(substring-before(string(string(.)), ':')) - 1)), '00')"/>
															<xsl:text>:</xsl:text>
															<xsl:value-of select="format-number(number(substring-before(substring-after(string(string(.)), ':'), ':')), '00')"/>
															<xsl:text>:</xsl:text>
															<xsl:choose>
																<xsl:when test="contains(string(string(.)), 'Z')">
																	<xsl:value-of select="format-number(number(substring-after(substring-after(substring-before(string(string(.)), 'Z'), ':'), ':')), '00')"/>
																</xsl:when>
																<xsl:when test="contains(string(string(.)), '+')">
																	<xsl:value-of select="format-number(number(substring-after(substring-after(substring-before(string(string(.)), '+'), ':'), ':')), '00')"/>
																</xsl:when>
																<xsl:when test="contains(substring-after(substring-after(string(string(.)), ':'), ':'), '-')">
																	<xsl:value-of select="format-number(number(substring-before(substring-after(substring-after(string(string(.)), ':')), ':'), '-'), '00')"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="format-number(number(substring-after(substring-after(string(string(.)), ':'), ':')), '00')"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</xsl:for-each>
												</td>
												<td align="center">
													<xsl:for-each select="n1:ReportName">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td align="center">
													<xsl:for-each select="n1:LawReason">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td align="center">
													<xsl:for-each select="n1:ConsumerAdministration">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td align="center">
													<xsl:for-each select="n1:Consumer">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td align="center">
													<xsl:for-each select="n1:Producer">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td align="center">
													<xsl:for-each select="n1:ProducerAdministration">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
								<br/>
								<xsl:if test="n1:TotalResults  &gt;  n1:MaxAllowedResults">
									<span>
										<xsl:text>Изобразени са първите </xsl:text>
									</span>
									<xsl:for-each select="n1:MaxAllowedResults">
										<xsl:apply-templates/>
									</xsl:for-each>
									<span>
										<xsl:text> от общо </xsl:text>
									</span>
									<xsl:for-each select="n1:TotalResults">
										<xsl:apply-templates/>
									</xsl:for-each>
									<span>
										<xsl:text> записа. Моля задайте по-специфични критерии!</xsl:text>
									</span>
								</xsl:if>
								<br/>
							</xsl:otherwise>
						</xsl:choose>
						<br/>
						<br/>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
