<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/MVR/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MVR/ObligationDocumentsByLicenceNum/GetObligationDocumentsByLicenceNumResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:GetObligationDocumentsByLicenceNumResponse">
						<h3 align="center">
							<span>
								<xsl:text>Министерство на вътрешните работи</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Проверка за налични неплатени документи в АИС АНД по номер на СУМПС и ЕГН</xsl:text>
							</span>
						</h2>
						<xsl:for-each select="n1:Status">
							<xsl:if test=". != 0">
								<span style="font-style:italic; ">
									<xsl:text>Статус:</xsl:text>
								</span>
								<xsl:choose>
									<xsl:when test=". =1">
										<span style="font-weight:bold; ">
											<xsl:text>Неуспешно отразено плащане</xsl:text>
										</span>
									</xsl:when>
									<xsl:when test=". =2">
										<span style="font-weight:bold; ">
											<xsl:text>Невалидни данни</xsl:text>
										</span>
									</xsl:when>
								</xsl:choose>
							</xsl:if>
							<span>
								<xsl:text>&#160;</xsl:text>
							</span>
						</xsl:for-each>
						<xsl:for-each select="n1:CustomerType">
							<br/>
							<span style="font-style:italic; ">
								<xsl:text>Тип на задълженото лице:</xsl:text>
							</span>
							<span>
								<xsl:text>&#160;</xsl:text>
							</span>
							<xsl:choose>
								<xsl:when test=". =&apos;person&apos;">
									<span style="font-weight:bold; ">
										<xsl:text>Физическо лице</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test=". =&apos;company&apos;">
									<span style="font-weight:bold; ">
										<xsl:text>Фирма</xsl:text>
									</span>
								</xsl:when>
								<xsl:otherwise>
									<span style="font-weight:bold; ">
										<xsl:apply-templates/>
									</span>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:for-each>
						<xsl:for-each select="n1:UserPID">
							<br/>
							<span style="font-style:italic; ">
								<xsl:text>ЕГН/ЛНЧ/ЛН или ЕИК/Булстат на задълженото лице:</xsl:text>
							</span>
							<span>
								<xsl:text>&#160;</xsl:text>
							</span>
							<span style="font-weight:bold; ">
								<xsl:apply-templates/>
							</span>
						</xsl:for-each>
						<br/>
						<br/>
						<xsl:choose>
							<xsl:when test="count( n1:ObligationDocuments/n1:ObligationDocument )&gt;0">
								<xsl:for-each select="n1:ObligationDocuments">
									<xsl:for-each select="n1:ObligationDocument">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Неплатен документ </xsl:text>
										</span>
										<span>
											<xsl:value-of select="position()"/>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text> :</xsl:text>
										</span>
										<br/>
										<xsl:for-each select="common:DocumentType">
											<span style="font-weight:bold; ">
												<xsl:text>Тип на документ:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:choose>
												<xsl:when test=". =&apos;ACT&apos;">
													<span>
														<xsl:text>АУАН</xsl:text>
													</span>
												</xsl:when>
												<xsl:when test=". =&apos;TICKET&apos;">
													<span>
														<xsl:text>ФИШ</xsl:text>
													</span>
												</xsl:when>
												<xsl:when test=". =&apos;PENAL_DECREE&apos;">
													<span>
														<xsl:text>НАКАЗАТЕЛНО ПОСТАНОВЛЕНИЕ</xsl:text>
													</span>
												</xsl:when>
												<xsl:otherwise>
													<span style="font-style:italic; ">
														<xsl:apply-templates/>
													</span>
												</xsl:otherwise>
											</xsl:choose>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:DocumentSeries">
											<span style="font-weight:bold; ">
												<xsl:text>Серия: </xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:DocumentNumber">
											<span style="font-weight:bold; ">
												<xsl:text>Номер на документ:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:InitialAmount">
											<span style="font-weight:bold; ">
												<xsl:text>Дължима сума:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:Discount">
											<span style="font-weight:bold; ">
												<xsl:text>Процент отстъпка:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:TotalAmount">
											<span style="font-weight:bold; ">
												<xsl:text>Сума за плащане (BGN):</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:IBAN">
											<span style="font-weight:bold; ">
												<xsl:text>IBAN на получателя:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:BIC">
											<span style="font-weight:bold; ">
												<xsl:text>BIC на получателя:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:PaymentReason">
											<span style="font-weight:bold; ">
												<xsl:text>Oснование за плащане: </xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:CreateDate">
											<span style="font-weight:bold; ">
												<xsl:text>Дата на издаване:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:IsMainDocument">
											<span style="font-weight:bold; ">
												<xsl:text>Документ по зададените параметри: </xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:choose>
												<xsl:when test=".  =true">
													<span style="font-weight:bold; ">
														<xsl:text>Да</xsl:text>
													</span>
												</xsl:when>
												<xsl:otherwise>
													<span style="font-weight:bold; ">
														<xsl:text>Не</xsl:text>
													</span>
												</xsl:otherwise>
											</xsl:choose>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="common:IsServed">
											<span style="font-weight:bold; ">
												<xsl:text>Идентификатор за връчен документ</xsl:text>
											</span>
											<span>
												<xsl:text>:&#160; </xsl:text>
											</span>
											<xsl:choose>
												<xsl:when test=". =true">
													<span style="font-weight:bold; ">
														<xsl:text>Да</xsl:text>
													</span>
												</xsl:when>
												<xsl:otherwise>
													<span style="font-weight:bold; ">
														<xsl:text>Не</xsl:text>
													</span>
												</xsl:otherwise>
											</xsl:choose>
										</xsl:for-each>
										<br/>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:when>
							<xsl:otherwise>
								<span>
									<xsl:text>Няма открити задължения по избраните от вас критерии.</xsl:text>
								</span>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
