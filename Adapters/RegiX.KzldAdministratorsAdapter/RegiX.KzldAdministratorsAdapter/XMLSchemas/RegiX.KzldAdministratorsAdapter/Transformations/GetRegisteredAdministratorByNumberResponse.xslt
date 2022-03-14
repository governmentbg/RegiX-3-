<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/KZLD/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/KZLD/Administrators/RegisteredAdministratorByNumberResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:decimal-format name="format1" grouping-separator=" " decimal-separator=","/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<br/>
					<br/>
					<br/>
					<h3 align="center">
						<span>
							<xsl:text>Комисия за защита на личните данни</xsl:text>
						</span>
					</h3>
					<h3 align="center">
						<span>
							<xsl:text>Регистър на вписаните администратори на лични данни</xsl:text>
						</span>
					</h3>
					<h2 align="center">
						<span>
							<xsl:text>Справка по Уникален идентификационен номер за вписан администратор на лични данни</xsl:text>
						</span>
					</h2>
					<xsl:for-each select="n1:RegisteredAdministratorByNumberResponse">
						<br/>
						<xsl:choose>
							<xsl:when test="count(n1:PDCRegisterNumer) = 0 and count( n1:PDCData ) = 0 and count( n1:PDSRegisters ) = 0">
								<span>
									<xsl:text>Няма намерени данни в регистъра!</xsl:text>
								</span>
							</xsl:when>
							<xsl:otherwise>
								<table border="1">
									<tbody>
										<tr>
											<td width="203">
												<span style="font-weight:bold; ">
													<xsl:text>Уникален идентификационен номер от Регистъра на вписаните администратори на лични данни</xsl:text>
												</span>
											</td>
											<td>
												<xsl:for-each select="n1:PDCRegisterNumer">
													<xsl:apply-templates/>
												</xsl:for-each>
											</td>
										</tr>
									</tbody>
								</table>
								<h3 align="center">
									<span>
										<xsl:text>Данни за администратора на лични данни:</xsl:text>
									</span>
								</h3>
								<table border="1">
									<tbody>
										<tr>
											<th align="left">
												<span>
													<xsl:text>Идентификатор - ЕИК/БУЛСТАТ/ЕГН/ЛНЧ</xsl:text>
												</span>
											</th>
											<xsl:for-each select="n1:PDCData">
												<td align="left">
													<xsl:for-each select="common:Identifier">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</xsl:for-each>
										</tr>
										<tr>
											<th align="left">
												<span>
													<xsl:text>Наименование на администратора на лични данни</xsl:text>
												</span>
											</th>
											<xsl:for-each select="n1:PDCData">
												<td align="left">
													<xsl:for-each select="common:Name">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</xsl:for-each>
										</tr>
										<tr>
											<th align="left">
												<span>
													<xsl:text>Правна форма на администратора на лични данни</xsl:text>
												</span>
											</th>
											<xsl:for-each select="n1:PDCData">
												<td align="left">
													<xsl:for-each select="common:LegalForm">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</xsl:for-each>
										</tr>
										<tr>
											<th align="left">
												<span>
													<xsl:text>Област/ Населено място на администратора на лични данни</xsl:text>
												</span>
											</th>
											<xsl:for-each select="n1:PDCData">
												<td align="left">
													<xsl:for-each select="common:Location">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</xsl:for-each>
										</tr>
										<tr>
											<th align="left">
												<span>
													<xsl:text>Адрес</xsl:text>
												</span>
											</th>
											<xsl:for-each select="n1:PDCData">
												<td align="left">
													<xsl:for-each select="common:Address">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</xsl:for-each>
										</tr>
										<tr>
											<th align="left">
												<span>
													<xsl:text>Код на област/населено място </xsl:text>
												</span>
											</th>
											<xsl:for-each select="n1:PDCData">
												<td align="left">
													<xsl:for-each select="common:LocationCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</xsl:for-each>
										</tr>
									</tbody>
								</table>
								<h3 align="center">
									<span>
										<xsl:text>Регистри, поддържани от администратора на лични данни:</xsl:text>
									</span>
								</h3>
								<table border="1">
									<thead>
										<tr>
											<th align="center">
												<span>
													<xsl:text>Номер</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Брой на физическите лица</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Наименование на поддържания регистър</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Дата на последна промяна в регистъра</xsl:text>
												</span>
											</th>
											<th align="center">
												<span>
													<xsl:text>Брой на физическите лица - текст</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="n1:PDSRegisters">
											<tr>
												<td>
													<span>
														<xsl:value-of select="position()"/>
													</span>
													<span>
														<xsl:text> от </xsl:text>
													</span>
													<span>
														<xsl:value-of select="count(../ n1:PDSRegisters)"/>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:IndividualsCount">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="common:RegisterName">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="common:UpdateDate">
														<span>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
														</span>
														<span>
															<xsl:text> г.</xsl:text>
														</span>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="common:IndividualsCountText">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:otherwise>
						</xsl:choose>
						<br/>
					</xsl:for-each>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
