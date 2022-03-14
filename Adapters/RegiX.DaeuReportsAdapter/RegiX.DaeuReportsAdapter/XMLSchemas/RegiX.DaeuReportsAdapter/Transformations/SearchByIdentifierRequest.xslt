<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/DaeuReports/SearchByIdentifierRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:SearchByIdentifierRequest">
						<br/>
						<h2 align="center">
							<span>
								<xsl:text>Входни параметри на Персонална справка на физическо лице за достъп до лични данни по идентификатор и период</xsl:text>
							</span>
						</h2>
						<br/>
						<table border="1" class="table-responsive" width="100%">
							<tbody>
								<tr>
									<td>
										<xsl:choose>
											<xsl:when test="n1:IdentifierType  = &apos;EGN&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>ЕГН</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test="n1:IdentifierType  = &apos;EIK&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>ЕИК</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test="n1:IdentifierType =&apos;Bulstat&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>БУЛСТАТ</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test="n1:IdentifierType  = &apos;LNCh&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>ЛНЧ</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test="n1:IdentifierType  = &apos;SystemNo&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>Системен Идентификатор</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test="n1:IdentifierType = &apos;BulstatCL&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>Чуждестранен БУЛСТАТ</xsl:text>
												</span>
											</xsl:when>
										</xsl:choose>
									</td>
									<td>
										<xsl:for-each select="n1:Identifier">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td>
										<span style="font-weight:bold; ">
											<xsl:text>От дата</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:DateFrom">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td>
										<span style="font-weight:bold; ">
											<xsl:text>До дата</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:DateTo">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
							</tbody>
						</table>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>